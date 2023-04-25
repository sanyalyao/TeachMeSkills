namespace home_8
{
    class RationCreater
    {
        public ListRationWithPerson<List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>>, Person> GetRationForPerson(Person person)
        {
            ListRationWithPerson<List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>>, Person> rationForPerson = new ListRationWithPerson<List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>>, Person>();

            rationForPerson.Value = MakeRation();
            rationForPerson.Key = person;

            return rationForPerson;
        }

        private List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>> MakeRation()
        {
            List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>> ration = new List<KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>>();

            foreach (DietSchedule.ScheduleFoodDays day in Enum.GetValues(typeof(DietSchedule.ScheduleFoodDays)))
            {
                ration.Add(new KeyValuePair<DietSchedule.ScheduleFoodDays, List<Product>>(day, new ListOfProducts().GetListOfProducts()));
            }

            return ration;
        }
    }
}
