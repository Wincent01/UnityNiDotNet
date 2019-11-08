using System;

namespace NiEditorApplication.Editor
{
    public enum MissionTextType
    {
        AcceptChatBubble,
        ChatState1,
        ChatState2,
        ChatState3,
        ChatState4,
        ChatState1TurnIn,
        ChatState2TurnIn,
        ChatState3TurnIn,
        ChatState4TurnIn,
        CompletionSucceedTip,
        InProgress,
        Offer,
        OfferRepeatable,
        ReadyToComplete
    }

    public static class MissionTextTypeExtensions
    {
        public static string Code(this MissionTextType @this)
        {
            switch (@this)
            {
                case MissionTextType.AcceptChatBubble:
                    return "accept_chat_bubble";
                case MissionTextType.ChatState1:
                    return "chat_state_1";
                case MissionTextType.ChatState2:
                    return "chat_state_2";
                case MissionTextType.ChatState3:
                    return "chat_state_3";
                case MissionTextType.ChatState4:
                    return "chat_state_4";
                case MissionTextType.ChatState1TurnIn:
                    return "chat_state_1_turnin";
                case MissionTextType.ChatState2TurnIn:
                    return "chat_state_2_turnin";
                case MissionTextType.ChatState3TurnIn:
                    return "chat_state_3_turnin";
                case MissionTextType.ChatState4TurnIn:
                    return "chat_state_4_turnin";
                case MissionTextType.CompletionSucceedTip:
                    return "completion_succeed_tip";
                case MissionTextType.InProgress:
                    return "in_progress";
                case MissionTextType.Offer:
                    return "offer";
                case MissionTextType.ReadyToComplete:
                    return "ready_to_complete";
                case MissionTextType.OfferRepeatable:
                    return "offer_repeatable";
                default:
                    throw new ArgumentOutOfRangeException(nameof(@this), @this, null);
            }
        }
    }
}