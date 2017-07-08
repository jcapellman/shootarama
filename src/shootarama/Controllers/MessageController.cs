using shootarama.Containers;
using shootarama.DB;
using shootarama.Enums;

using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace shootarama.Controllers
{
    public class MessageController
    {
        private ConcurrentStack<MessageContainer> _stack;

        public MessageController()
        {
            _stack = new ConcurrentStack<MessageContainer>();
        }

        public void AddMessageAsync(MessageType messageType, dynamic data)
        {
            _stack.Push(new MessageContainer(messageType, data));
        }

        public async void ProcessQueue()
        {
            while (_stack.Any())
            {
                _stack.TryPop(out MessageContainer container);

                switch (container.MessageType)
                {
                    case MessageType.GAMES_GET_LIST:
                        break;
                    case MessageType.SQLITE_INITIALIZE:
                        InitializeSQLiteDB();
                        break;
                }

                await Task.Delay(200);
            }
        }

        private void InitializeSQLiteDB()
        {
            using (var db = new DBManager())
            {
                db.Initialize();
            }
        }
    }
}