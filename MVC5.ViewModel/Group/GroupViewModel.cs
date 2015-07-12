using System.ComponentModel;

namespace MVC5.ViewModel.Group
{
    public class GroupViewModel
    {
        [DisplayName("شماره")]
        public int Id { get; set; }
        [DisplayName("نام گروه")]
        public string Name { get; set; }
        [DisplayName("توضیحات")]
        public string Description { get; set; }
    }
}
