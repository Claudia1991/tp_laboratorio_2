﻿namespace Ventas.Modelos.DataModels
{
    public abstract class BaseDataModel
    {
        public int Id { get; set; }

        protected BaseDataModel(int id)
        {
            Id = id;
        }
    }
}
