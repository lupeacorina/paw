using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw1.Module
{
    public class InvalidDateException : Exception
	{
		public DateTime Data { get; set; }

		public InvalidDateException(DateTime data)
		{
			Data = data;
		}

		public override string Message
		{
			get
			{
				return "Data imprumutului " + Data + " este invalida";
			}
		}
	}
}
