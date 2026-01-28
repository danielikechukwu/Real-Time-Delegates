public delegate void WorkPerformedHandler(int hours, string workType);

public delegate void WorkComplementedHandler(string workType);

public class Worker
{

    public void DoWork(int hours, string workType, WorkPerformedHandler del1, WorkComplementedHandler del2)
    {
        for(int i = 0; i < hours; i++)
        {
            // Do some processing
            Thread.Sleep(1000);

            //Notify how much works have been done
            del1(i + 1, workType);
        }

        //Notify the consumer that work has been completed.
        del2(workType);
    }

    public static void Main(string[] args)
    {
        WorkPerformedHandler del1 = new WorkPerformedHandler(_WorkPerformed);
        WorkComplementedHandler del2 = new WorkComplementedHandler(_WorkCompleted);

    }

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