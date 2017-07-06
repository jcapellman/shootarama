using shootarama.Enums;

namespace shootarama.Containers
{
    public class MessageContainer
    {
        public MessageType MessageType { get; set; }

        public dynamic Data { get; set; }

        public MessageContainer() { }

        public MessageContainer(MessageType messageType, dynamic data)
        {
            MessageType = messageType;
            Data = data;
        }
    }
}