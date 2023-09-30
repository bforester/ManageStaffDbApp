﻿namespace ManageStaffDbApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
