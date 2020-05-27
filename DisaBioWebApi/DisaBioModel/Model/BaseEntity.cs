using System;
using System.Collections.Generic;
using System.Text;

namespace DisaBioModel.Model
{
    abstract class BaseEntity
    {
        // Attributes
        private int id;

        // Properties
        public int ID { get => id; set => id = value; }

        // Constructor
        public BaseEntity() { }
        protected BaseEntity(int id)
        {
            ID = id;
        }
    }
}
