
    public class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; } 
        public string Phone { get; set; }
        
        public string GetInfo() {
            return $"\nІм'я: {Name}\nВік: {Age}\nЕлектронна пошта: {Email}\nНомер Телефону: {Phone}\n";
    
    }

    }

