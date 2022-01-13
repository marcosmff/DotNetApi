﻿namespace SmartSchool.API.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;

        public int PageNumber { get; set; } = 1;

        private int pageSize { get; set; } = 10;

        public int PageSize { get { return pageSize; } 
                              set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
                            }

        public int? Matricula { get; set; } = null;

        public string Nome { get; set; } = string.Empty;

        public bool? Ativo { get; set; } = null;
    }
}
