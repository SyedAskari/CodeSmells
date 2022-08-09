namespace Code.Smells.Class
{
    public class ReplaceInheritanceWithDelegation {
    
    }

    public class Company : List<Manager>
    {
        public IEnumerable<Manager> ListCurrentManagers()
        {
            return this.Where(m => m.IsEmployed).AsEnumerable();
        }

        public void Hire(Manager manager)
        {
            this.Add(manager);
        }

        public void Fire(Manager manager)
        {
            this.Remove(manager);
        }
    }

    public class ClientCode
    {
        public void Main()
        {
            var company = new Company();
            var managers = company.ListCurrentManagers();
            var manager = new Manager();
            
            // ok
            company.Hire(manager);
            
            // ok
            company.Fire(manager);
            
            // should not be allowed
            company.Clear();
        }
    }
    public class Manager
    {
        public bool IsEmployed { get; set; }
    }

    public class Company_ReplaceInheritanceWithDelegation
    {
        private List<Manager> _managers = new List<Manager>();
        
        public IEnumerable<Manager> ListCurrentManagers()
        {
            return _managers.Where(m => m.IsEmployed).AsEnumerable();
        }

        public void Hire(Manager manager)
        {
            _managers.Add(manager);
        }

        public void Fire(Manager manager)
        {
            _managers.Remove(manager);
        }
    }
    
    public class ClientCode_Using_Company_ReplaceInheritanceWithDelegationApproach
    {
        public void Main()
        {
            var company = new Company_ReplaceInheritanceWithDelegation();
            var managers = company.ListCurrentManagers();
            var manager = new Manager();
            
            // ok
            company.Hire(manager);
            
            // ok
            company.Fire(manager);
            
            // not going to work
            // company.Clear();
        }
    }
}