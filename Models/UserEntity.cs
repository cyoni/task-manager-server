﻿namespace Model
{
    public class UserEntity
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
    }
}