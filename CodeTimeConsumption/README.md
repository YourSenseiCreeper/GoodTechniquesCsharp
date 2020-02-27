# CodeTimeConsumption
The goal of this project was to test how can you meter time that your method consumes. Following that I tried to test it with **System.Diagnostics.Stopwatch**, but unfortunately it turned out, **Stopwatch** is giving various results. 
## Included time consumption tests
 - String interpolation **vs** default formatting
 - *ViewHelper.AskForDouble* method refactoring process
 - ViewHelper.AskForDouble as a static method from static class **vs** ViewHelper.AskForDouble as a public method from class used as object

## Fix
In order to fix it I searched the Internet and found a guy who wanted to do the exact the same thing. [Thomas Maierhofer](https://www.codeproject.com/script/Membership/View.aspx?mid=3921144) from CodePoint points out:

> ...everybody has noticed that the measurements of the same function on the same computer can differ 25% -30% in run time.

If you're interested in [read full article here](https://www.codeproject.com/Articles/61964/Performance-Tests-Precise-Run-Time-Measurements-wi). First I ran my tests on debug mode in VS. That was very very wrong, as Thomas says. Even if I ran those tests running directly an .exe file results were not satisfying. Time varied from **0.3ms** to about **30ms**. Such huge variations is not acceptable! This made me thinking what's wrong with the project. As I have been suspecting the problem was normal ThreadPriority and running on one CPU core. Thomas presents a fix for that:

    Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2); // Use only the second core
    Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
    Thread.CurrentThread.Priority = ThreadPriority.Highest;
Even though he recommends doing "warm up" (for CPU) before running your loop with tested method.

> stopwatch.Start();
while (stopwatch.ElapsedMilliseconds < 1200)
{
    // Use your test function here
}
stopwatch.Stop();