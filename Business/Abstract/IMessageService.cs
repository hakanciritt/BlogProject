using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        Task<IDataResult<List<Message>>> GetMessageListByWriterMailAsync(string mail);
    }
}
