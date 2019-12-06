using System;

namespace Chapter1
{
    class Alarm
    {
        // Delegate for the alarm event
        public event Action OnAlarmRaised = delegate { };

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has
            // subscribed. 
            OnAlarmRaised?.Invoke();
        }

        public void AddListerners ()
        {

            // Connect the two listener methods
            OnAlarmRaised += AlarmListener1;
            OnAlarmRaised += AlarmListener2;
        }
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 called");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

    }
    class Alarm2
    {
        // Delegate for the alarm event
        public event EventHandler OnAlarmRaised = delegate { };

        // Called to raise an alarm
        // Does not provide any event arguments
        public void RaiseAlarm()
        {
            // Raises the alarm
            // The event handler receivers a reference to the alarm that is 
            // raising this event
            OnAlarmRaised(this, EventArgs.Empty);
        }

    }

    /// <summary>
    /// Unsafe solution
    /// </summary>
    class Events
    {
        // Method that must run when the alarm is raised
        public void EventsStart()
        {
            // Create a new alarm
            Alarm alarm = new Alarm();
            alarm.AddListerners();


            // raise the alarm
            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised");


            // Create a new alarm
            Alarm2 alarm2 = new Alarm2();
            alarm2.RaiseAlarm();


            Console.ReadKey();
        }
    }

}
