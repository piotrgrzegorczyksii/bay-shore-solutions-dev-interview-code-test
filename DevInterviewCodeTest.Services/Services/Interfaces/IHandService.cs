using System.Collections.Generic;
using DevInterviewCodeTest.Services.Models;

namespace DevInterviewCodeTest.Services.Services.Interfaces
{
    public interface IHandService
    {
        IEnumerable<Hand> GetHands(int count = 1);
    }
}
