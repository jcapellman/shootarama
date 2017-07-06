using shootarama.Containers;
using shootarama.Enums;

using System.Collections.Concurrent;
using System.Linq;

namespace shootarama.Controllers
{
    public class MessageController
    {
        private ConcurrentStack<MessageContainer> _stack;

        public void AddMessageAsync(MessageType messageType, dynamic data)
        {
            _stack.Push(new MessageContainer(messageType, data));
        }

        public void ProcessQueue()
        {
            while (_stack.Any())
            {

                _stack.TryPop(out MessageContainer container);

                switch (container.MessageType)
                {
                    case MessageType.GAMES_GET_LIST:
                        break;
                }
            }
        }
    }
}