using ChainofResponsibilityUserInteface.Models;

namespace ChainofResponsibilityUserInteface.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextAppover(Employee superVisior)
        {
            this.NextApprover = superVisior;
        }

        public abstract void ProcessRequest(CustomerProcessViewModel model);
    }
}