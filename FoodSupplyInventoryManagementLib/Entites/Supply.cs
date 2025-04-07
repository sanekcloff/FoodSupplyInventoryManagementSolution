using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodSupplyInventoryManagementLib.Entites
{
    public class Supply
    {
        public Guid Id { get; set; }

        public decimal TotalCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public Status Statuses { get; set; }

        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; } = null!;

        public virtual IEnumerable<SupplyItem> SupplyItems { get; set; } = null!;

        [NotMapped]
        public string StatusAsString
        {
            get
            {
                switch (Statuses)
                {
                    case Status.Waiting:
                        return "Ожидание";
                    case Status.InProgres:
                        return "Выполняется";
                    case Status.Completed:
                        return "Завершён";
                    case Status.Canceled:
                        return "Отменён";
                    default:
                        return "Не выбран";
                }
            }
        }
    }

    public enum Status
    {
        Waiting,
        InProgres,
        Canceled,
        Completed
    }
}
