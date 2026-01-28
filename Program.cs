using Real_Time_Delegates;

public delegate void WorkPerformedHandler(int hours, string workType);

public delegate void WorkComplementedHandler(string workType);

public class Worker
{

    public void DoWork(int hours, string workType, WorkPerformedHandler del1, WorkComplementedHandler del2)
    {

        del1 = null; //Allowing to set null
        del2 = null; //Allowing to set null

        for(int i = 0; i < hours; i++)
        {
            // Do some processing
            Thread.Sleep(1000);
            Console.WriteLine($"{del1} :: First Delegate");

            //Notify how much works have been done
            del1(i + 1, workType);
        }

        //Notify the consumer that work has been completed.
        del2(workType);
    }

    public static void Main(string[] args)
    {
        //WorkPerformedHandler del1 = new WorkPerformedHandler(_WorkPerformed);
        //WorkComplementedHandler del2 = new WorkComplementedHandler(_WorkCompleted);

        //Worker worker = new Worker();
        //worker.DoWork(5, "Generating Report", del1, del2);
        //Console.ReadKey();

        // REAL - TIME DELEGATES

        Employee emp1 = new Employee()
        {
            ID = 101,
            Name = "Pranaya",
            Gender = "Male",
            Experience = 5,
            Salary = 10000
        };

        Employee emp2 = new Employee()
        {
            ID = 102,
            Name = "Priyanka",
            Gender = "Female",
            Experience = 10,
            Salary = 20000
        };

        Employee emp3 = new Employee()
        {
            ID = 103,
            Name = "Anurag",
            Experience = 15,
            Salary = 30000
        };

        List<Employee> lstEmployees = new List<Employee>();

        lstEmployees.Add(emp1);
        lstEmployees.Add(emp2);
        lstEmployees.Add(emp3);

        //EligibleToPromotion eligibleToPromote = new EligibleToPromotion(Promote);

        //Employees.PromoteEmployee(lstEmployees, eligibleToPromote);

        // Working with LAMBDA Expression
        Employees.PromoteEmployee(lstEmployees, x => x.Experience > 5);

    }

    //public static bool Promote(Employee employee)
    //{
    //    if (employee.Salary > 10000)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //Delegate Signature must match with the method signature
    public static void _WorkPerformed(int hours, string workType)
    {
        Console.WriteLine($"{hours} Hour completed for {workType}");
    }

    public static void _WorkCompleted(string workType)
    {
        Console.WriteLine($"{workType} work completed"); 
    }
}

public delegate bool EligibleToPromotion(Employee EmployeeToPromotion);

public class Employees
{
    public int ID { get; set; }

    public string Name { get; set; }

    public string Gender { get; set; }

    public int Experience { get; set; }

    public int Salary { get; set; }

    public static void PromoteEmployee(List<Employee> lstEmployees, EligibleToPromotion IsEmployeeEligible)
    {
        foreach(Employee employee in lstEmployees)
        {
            if(IsEmployeeEligible(employee))
            {
                Console.WriteLine($"Employee {employee.Name} Promoted");
            }
        }
    }
}