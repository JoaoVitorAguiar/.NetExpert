using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModel;

public class UserViewModel
{
    public UserViewModel(int id, string fisrtName, string lastName, string email)
    {
        Id = id;
        FisrtName = fisrtName;
        LastName = lastName;
        Email = email;
    }
    public int Id { get; private set; }

    public string FisrtName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
}
