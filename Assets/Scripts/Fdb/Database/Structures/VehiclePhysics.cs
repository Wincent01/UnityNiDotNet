using NiEditorApplication.Fdb;
using System.Linq;

namespace Fdb.Database
{
	class VehiclePhysics
	{
		public Row DatabaseRow { get; set; }
		public Table DatabaseTable { get; set; }

		public int id
		{
			get => (int) DatabaseRow.Fields[0].Value;
			set
			{
				DatabaseRow.Fields[0].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string hkxFilename
		{
			get => (string) DatabaseRow.Fields[1].Value;
			set
			{
				DatabaseRow.Fields[1].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fGravityScale
		{
			get => (float) DatabaseRow.Fields[2].Value;
			set
			{
				DatabaseRow.Fields[2].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fMass
		{
			get => (float) DatabaseRow.Fields[3].Value;
			set
			{
				DatabaseRow.Fields[3].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fChassisFriction
		{
			get => (float) DatabaseRow.Fields[4].Value;
			set
			{
				DatabaseRow.Fields[4].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fMaxSpeed
		{
			get => (float) DatabaseRow.Fields[5].Value;
			set
			{
				DatabaseRow.Fields[5].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fEngineTorque
		{
			get => (float) DatabaseRow.Fields[6].Value;
			set
			{
				DatabaseRow.Fields[6].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBrakeFrontTorque
		{
			get => (float) DatabaseRow.Fields[7].Value;
			set
			{
				DatabaseRow.Fields[7].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBrakeRearTorque
		{
			get => (float) DatabaseRow.Fields[8].Value;
			set
			{
				DatabaseRow.Fields[8].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBrakeMinInputToBlock
		{
			get => (float) DatabaseRow.Fields[9].Value;
			set
			{
				DatabaseRow.Fields[9].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBrakeMinTimeToBlock
		{
			get => (float) DatabaseRow.Fields[10].Value;
			set
			{
				DatabaseRow.Fields[10].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSteeringMaxAngle
		{
			get => (float) DatabaseRow.Fields[11].Value;
			set
			{
				DatabaseRow.Fields[11].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSteeringSpeedLimitForMaxAngle
		{
			get => (float) DatabaseRow.Fields[12].Value;
			set
			{
				DatabaseRow.Fields[12].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSteeringMinAngle
		{
			get => (float) DatabaseRow.Fields[13].Value;
			set
			{
				DatabaseRow.Fields[13].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fFwdBias
		{
			get => (float) DatabaseRow.Fields[14].Value;
			set
			{
				DatabaseRow.Fields[14].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fFrontTireFriction
		{
			get => (float) DatabaseRow.Fields[15].Value;
			set
			{
				DatabaseRow.Fields[15].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fRearTireFriction
		{
			get => (float) DatabaseRow.Fields[16].Value;
			set
			{
				DatabaseRow.Fields[16].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fFrontTireFrictionSlide
		{
			get => (float) DatabaseRow.Fields[17].Value;
			set
			{
				DatabaseRow.Fields[17].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fRearTireFrictionSlide
		{
			get => (float) DatabaseRow.Fields[18].Value;
			set
			{
				DatabaseRow.Fields[18].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fFrontTireSlipAngle
		{
			get => (float) DatabaseRow.Fields[19].Value;
			set
			{
				DatabaseRow.Fields[19].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fRearTireSlipAngle
		{
			get => (float) DatabaseRow.Fields[20].Value;
			set
			{
				DatabaseRow.Fields[20].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelWidth
		{
			get => (float) DatabaseRow.Fields[21].Value;
			set
			{
				DatabaseRow.Fields[21].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelRadius
		{
			get => (float) DatabaseRow.Fields[22].Value;
			set
			{
				DatabaseRow.Fields[22].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelMass
		{
			get => (float) DatabaseRow.Fields[23].Value;
			set
			{
				DatabaseRow.Fields[23].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fReorientPitchStrength
		{
			get => (float) DatabaseRow.Fields[24].Value;
			set
			{
				DatabaseRow.Fields[24].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fReorientRollStrength
		{
			get => (float) DatabaseRow.Fields[25].Value;
			set
			{
				DatabaseRow.Fields[25].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSuspensionLength
		{
			get => (float) DatabaseRow.Fields[26].Value;
			set
			{
				DatabaseRow.Fields[26].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSuspensionStrength
		{
			get => (float) DatabaseRow.Fields[27].Value;
			set
			{
				DatabaseRow.Fields[27].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSuspensionDampingCompression
		{
			get => (float) DatabaseRow.Fields[28].Value;
			set
			{
				DatabaseRow.Fields[28].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSuspensionDampingRelaxation
		{
			get => (float) DatabaseRow.Fields[29].Value;
			set
			{
				DatabaseRow.Fields[29].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int iChassisCollisionGroup
		{
			get => (int) DatabaseRow.Fields[30].Value;
			set
			{
				DatabaseRow.Fields[30].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fNormalSpinDamping
		{
			get => (float) DatabaseRow.Fields[31].Value;
			set
			{
				DatabaseRow.Fields[31].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fCollisionSpinDamping
		{
			get => (float) DatabaseRow.Fields[32].Value;
			set
			{
				DatabaseRow.Fields[32].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fCollisionThreshold
		{
			get => (float) DatabaseRow.Fields[33].Value;
			set
			{
				DatabaseRow.Fields[33].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fTorqueRollFactor
		{
			get => (float) DatabaseRow.Fields[34].Value;
			set
			{
				DatabaseRow.Fields[34].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fTorquePitchFactor
		{
			get => (float) DatabaseRow.Fields[35].Value;
			set
			{
				DatabaseRow.Fields[35].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fTorqueYawFactor
		{
			get => (float) DatabaseRow.Fields[36].Value;
			set
			{
				DatabaseRow.Fields[36].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInertiaRoll
		{
			get => (float) DatabaseRow.Fields[37].Value;
			set
			{
				DatabaseRow.Fields[37].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInertiaPitch
		{
			get => (float) DatabaseRow.Fields[38].Value;
			set
			{
				DatabaseRow.Fields[38].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInertiaYaw
		{
			get => (float) DatabaseRow.Fields[39].Value;
			set
			{
				DatabaseRow.Fields[39].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fExtraTorqueFactor
		{
			get => (float) DatabaseRow.Fields[40].Value;
			set
			{
				DatabaseRow.Fields[40].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fCenterOfMassFwd
		{
			get => (float) DatabaseRow.Fields[41].Value;
			set
			{
				DatabaseRow.Fields[41].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fCenterOfMassUp
		{
			get => (float) DatabaseRow.Fields[42].Value;
			set
			{
				DatabaseRow.Fields[42].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fCenterOfMassRight
		{
			get => (float) DatabaseRow.Fields[43].Value;
			set
			{
				DatabaseRow.Fields[43].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointFrontFwd
		{
			get => (float) DatabaseRow.Fields[44].Value;
			set
			{
				DatabaseRow.Fields[44].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointFrontUp
		{
			get => (float) DatabaseRow.Fields[45].Value;
			set
			{
				DatabaseRow.Fields[45].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointFrontRight
		{
			get => (float) DatabaseRow.Fields[46].Value;
			set
			{
				DatabaseRow.Fields[46].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointRearFwd
		{
			get => (float) DatabaseRow.Fields[47].Value;
			set
			{
				DatabaseRow.Fields[47].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointRearUp
		{
			get => (float) DatabaseRow.Fields[48].Value;
			set
			{
				DatabaseRow.Fields[48].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWheelHardpointRearRight
		{
			get => (float) DatabaseRow.Fields[49].Value;
			set
			{
				DatabaseRow.Fields[49].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputTurnSpeed
		{
			get => (float) DatabaseRow.Fields[50].Value;
			set
			{
				DatabaseRow.Fields[50].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputDeadTurnBackSpeed
		{
			get => (float) DatabaseRow.Fields[51].Value;
			set
			{
				DatabaseRow.Fields[51].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputAccelSpeed
		{
			get => (float) DatabaseRow.Fields[52].Value;
			set
			{
				DatabaseRow.Fields[52].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputDeadAccelDownSpeed
		{
			get => (float) DatabaseRow.Fields[53].Value;
			set
			{
				DatabaseRow.Fields[53].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputDecelSpeed
		{
			get => (float) DatabaseRow.Fields[54].Value;
			set
			{
				DatabaseRow.Fields[54].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputDeadDecelDownSpeed
		{
			get => (float) DatabaseRow.Fields[55].Value;
			set
			{
				DatabaseRow.Fields[55].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputSlopeChangePointX
		{
			get => (float) DatabaseRow.Fields[56].Value;
			set
			{
				DatabaseRow.Fields[56].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputInitialSlope
		{
			get => (float) DatabaseRow.Fields[57].Value;
			set
			{
				DatabaseRow.Fields[57].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fInputDeadZone
		{
			get => (float) DatabaseRow.Fields[58].Value;
			set
			{
				DatabaseRow.Fields[58].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fAeroAirDensity
		{
			get => (float) DatabaseRow.Fields[59].Value;
			set
			{
				DatabaseRow.Fields[59].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fAeroFrontalArea
		{
			get => (float) DatabaseRow.Fields[60].Value;
			set
			{
				DatabaseRow.Fields[60].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fAeroDragCoefficient
		{
			get => (float) DatabaseRow.Fields[61].Value;
			set
			{
				DatabaseRow.Fields[61].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fAeroLiftCoefficient
		{
			get => (float) DatabaseRow.Fields[62].Value;
			set
			{
				DatabaseRow.Fields[62].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fAeroExtraGravity
		{
			get => (float) DatabaseRow.Fields[63].Value;
			set
			{
				DatabaseRow.Fields[63].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBoostTopSpeed
		{
			get => (float) DatabaseRow.Fields[64].Value;
			set
			{
				DatabaseRow.Fields[64].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBoostCostPerSecond
		{
			get => (float) DatabaseRow.Fields[65].Value;
			set
			{
				DatabaseRow.Fields[65].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBoostAccelerateChange
		{
			get => (float) DatabaseRow.Fields[66].Value;
			set
			{
				DatabaseRow.Fields[66].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fBoostDampingChange
		{
			get => (float) DatabaseRow.Fields[67].Value;
			set
			{
				DatabaseRow.Fields[67].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fPowerslideNeutralAngle
		{
			get => (float) DatabaseRow.Fields[68].Value;
			set
			{
				DatabaseRow.Fields[68].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fPowerslideTorqueStrength
		{
			get => (float) DatabaseRow.Fields[69].Value;
			set
			{
				DatabaseRow.Fields[69].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public int iPowerslideNumTorqueApplications
		{
			get => (int) DatabaseRow.Fields[70].Value;
			set
			{
				DatabaseRow.Fields[70].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fImaginationTankSize
		{
			get => (float) DatabaseRow.Fields[71].Value;
			set
			{
				DatabaseRow.Fields[71].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fSkillCost
		{
			get => (float) DatabaseRow.Fields[72].Value;
			set
			{
				DatabaseRow.Fields[72].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWreckSpeedBase
		{
			get => (float) DatabaseRow.Fields[73].Value;
			set
			{
				DatabaseRow.Fields[73].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWreckSpeedPercent
		{
			get => (float) DatabaseRow.Fields[74].Value;
			set
			{
				DatabaseRow.Fields[74].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float fWreckMinAngle
		{
			get => (float) DatabaseRow.Fields[75].Value;
			set
			{
				DatabaseRow.Fields[75].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventEngine
		{
			get => (string) DatabaseRow.Fields[76].Value;
			set
			{
				DatabaseRow.Fields[76].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventSkid
		{
			get => (string) DatabaseRow.Fields[77].Value;
			set
			{
				DatabaseRow.Fields[77].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventLightHit
		{
			get => (string) DatabaseRow.Fields[78].Value;
			set
			{
				DatabaseRow.Fields[78].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioSpeedThresholdLightHit
		{
			get => (float) DatabaseRow.Fields[79].Value;
			set
			{
				DatabaseRow.Fields[79].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioTimeoutLightHit
		{
			get => (float) DatabaseRow.Fields[80].Value;
			set
			{
				DatabaseRow.Fields[80].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventHeavyHit
		{
			get => (string) DatabaseRow.Fields[81].Value;
			set
			{
				DatabaseRow.Fields[81].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioSpeedThresholdHeavyHit
		{
			get => (float) DatabaseRow.Fields[82].Value;
			set
			{
				DatabaseRow.Fields[82].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioTimeoutHeavyHit
		{
			get => (float) DatabaseRow.Fields[83].Value;
			set
			{
				DatabaseRow.Fields[83].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventStart
		{
			get => (string) DatabaseRow.Fields[84].Value;
			set
			{
				DatabaseRow.Fields[84].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadConcrete
		{
			get => (string) DatabaseRow.Fields[85].Value;
			set
			{
				DatabaseRow.Fields[85].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadSand
		{
			get => (string) DatabaseRow.Fields[86].Value;
			set
			{
				DatabaseRow.Fields[86].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadWood
		{
			get => (string) DatabaseRow.Fields[87].Value;
			set
			{
				DatabaseRow.Fields[87].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadDirt
		{
			get => (string) DatabaseRow.Fields[88].Value;
			set
			{
				DatabaseRow.Fields[88].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadPlastic
		{
			get => (string) DatabaseRow.Fields[89].Value;
			set
			{
				DatabaseRow.Fields[89].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadGrass
		{
			get => (string) DatabaseRow.Fields[90].Value;
			set
			{
				DatabaseRow.Fields[90].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadGravel
		{
			get => (string) DatabaseRow.Fields[91].Value;
			set
			{
				DatabaseRow.Fields[91].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadMud
		{
			get => (string) DatabaseRow.Fields[92].Value;
			set
			{
				DatabaseRow.Fields[92].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadWater
		{
			get => (string) DatabaseRow.Fields[93].Value;
			set
			{
				DatabaseRow.Fields[93].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadSnow
		{
			get => (string) DatabaseRow.Fields[94].Value;
			set
			{
				DatabaseRow.Fields[94].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadIce
		{
			get => (string) DatabaseRow.Fields[95].Value;
			set
			{
				DatabaseRow.Fields[95].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadMetal
		{
			get => (string) DatabaseRow.Fields[96].Value;
			set
			{
				DatabaseRow.Fields[96].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventTreadLeaves
		{
			get => (string) DatabaseRow.Fields[97].Value;
			set
			{
				DatabaseRow.Fields[97].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventLightLand
		{
			get => (string) DatabaseRow.Fields[98].Value;
			set
			{
				DatabaseRow.Fields[98].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioAirtimeForLightLand
		{
			get => (float) DatabaseRow.Fields[99].Value;
			set
			{
				DatabaseRow.Fields[99].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public string AudioEventHeavyLand
		{
			get => (string) DatabaseRow.Fields[100].Value;
			set
			{
				DatabaseRow.Fields[100].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public float AudioAirtimeForHeavyLand
		{
			get => (float) DatabaseRow.Fields[101].Value;
			set
			{
				DatabaseRow.Fields[101].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public bool bWheelsVisible
		{
			get => (bool) DatabaseRow.Fields[102].Value;
			set
			{
				DatabaseRow.Fields[102].Value = value;
				DatabaseTable.UpdateRow(DatabaseRow);
			}
		}

		public VehiclePhysics(Row databaseRow)
		{
			DatabaseRow = databaseRow;
			DatabaseTable = FdbEditor.Database.Tables.First(t => t.Name == "VehiclePhysics");
		}
	}
}
