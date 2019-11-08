using System;
using System.Collections.Generic;
using System.Linq;
using Fdb.Database;
using Fdb.Enums;
using NiEditorApplication.Editor;

namespace Fdb.Object
{
    public class FdbObject
    {
        public readonly int Lot;
        
        public readonly List<ObjectComponent> Components = new List<ObjectComponent>();

        public FdbObject(int lot)
        {
            Lot = lot;
        }
        
        public void AddComponent(ReplicaComponentsId componentId)
        {
            var component = new ObjectComponent
            {
                ComponentType = componentId
            };
            
            var table = FdbEditor.Database.Tables.FirstOrDefault(t => t.Name == componentId.ToString());

            var componentRow = new ComponentsRegistry(new Row(new[]
            {
                new Field(DataType.Integer, 0), new Field(DataType.Integer, 0), new Field(DataType.Integer, 0),
            }));
            
            component.RegistryRow = componentRow.DatabaseRow;
            componentRow.DatabaseTable = ObjectEditor.ComponentsTable;
            ObjectEditor.ComponentsTable.AppendRow(component.RegistryRow);
            
            componentRow.id = Lot;
            componentRow.component_type = (int) componentId;
            componentRow.component_id = table?.Rows.Select(r => (int) r.Fields[0].Value).Max() + 1 ?? default;

            if (table != default)
            {
                var fields = new Field[table.Structure.Length];

                for (var index = 0; index < fields.Length; index++)
                {
                    var field = table.Structure[index];

                    fields[index] = new Field(field.Type, 0);

                    switch (field.Type)
                    {
                        case DataType.Nothing:
                            fields[index].Value = 0;
                            break;
                        case DataType.Integer:
                            fields[index].Value = 0;
                            break;
                        case DataType.Unknown1:
                            fields[index].Value = 0;
                            break;
                        case DataType.Float:
                            fields[index].Value = 0;
                            break;
                        case DataType.Text:
                            fields[index].Value = "";
                            break;
                        case DataType.Boolean:
                            fields[index].Value = false;
                            break;
                        case DataType.Bigint:
                            fields[index].Value = 0;
                            break;
                        case DataType.Unknown2:
                            fields[index].Value = 0;
                            break;
                        case DataType.Varchar:
                            fields[index].Value = "";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                fields[0].Value = componentRow.component_id;

                component.ComponentRow = new Row(fields);
                table.AppendRow(component.ComponentRow);
            }
            
            Components.Add(component);
        }

        public void DeleteComponent(ReplicaComponentsId componentId)
        {
            var component = Components.First(c => c.ComponentType == componentId);
            
            var table = FdbEditor.Database.Tables.FirstOrDefault(t => t.Name == componentId.ToString());

            if (component.ComponentRow != null) table?.DeleteRow(component.ComponentRow);

            ObjectEditor.ComponentsTable.DeleteRow(component.RegistryRow);

            Components.Remove(component);
        }
    }
}