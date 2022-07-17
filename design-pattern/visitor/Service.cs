using System;

namespace visitor
{
		public interface  IDomain 
		{
		  void Accept(IVisitor visitor);
		}

		public interface IVisitor 
		{
			void Visit(ServiceOrder serviceOrder );
			void Visit(ServiceLineItem serviceLineItem );
		}

		public class Address 
		{
		}

    public class ServiceOrder : IDomain
	{
		public int Id {get; set;}
		public Address CustomerAddress {get; set; }
		public List<ServiceLineItem> ServiceLineItems { get; set; }

		public  Accept(IVisitor visitor)
		{
			visitor.Visit(this);
			foreach (var item in this.ServiceLineItmes)
			{
					item.Accept(item);
			}
		}
	}

	public class ServiceOrderLineItem : IDomain
	{
		public Item Item { get; set; }
		public int Qty {get;set;}
		public int UnitCost { get; set; }
		public  Accept(IVisitor visitor)
		{
				item.Visit(this);
		}
	}

	 public class Item 
	 {
		    public string Name { get; set; }
			public string ShortName { get; set; }
	 }
}