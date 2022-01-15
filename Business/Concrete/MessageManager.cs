using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }
        public async Task<IDataResult<List<Message>>> GetMessageListByWriterMailAsync(string mail)
        {
            return new SuccessDataResult<List<Message>>(await _messageDal.GetAllAsync(x => x.Receiver == mail));
        }
    }
}
