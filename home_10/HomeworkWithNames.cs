namespace home_10
{
    class HomeworkWithNames
    {
        /// <summary>
        /// Напишите метод, который возвращает "<FirstName> <MiddleName> <LastName>", если отчество присутствует Или "<FirstName> <LastName>", если отчество отсутствует.
        /// </summary>
        public string FirstMethod(User user)
        {
            if (!String.IsNullOrEmpty(user.MiddleName))
            {
                return $"{user.FirstName} {user.MiddleName} {user.LastName}";
            }
            else
            {
                return $"{user.FirstName} {user.LastName}";
            }
        }

        /// <summary>
        /// Напишите метод, который возвращает предоставленный список пользователей, упорядоченный по LastName в порядке убывания.
        /// </summary>
        public List<User> SecondMethod(List<User> users)
        {
            return users.OrderByDescending(user => user.LastName).ToList();
        }
    }
}
