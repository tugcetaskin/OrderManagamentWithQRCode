using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly ITableForCustomerService _tableForCustomerService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly ITableForCustomerService _table;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, ITableForCustomerService tableForCustomerService, IBookingService bookingService, INotificationService notificationService, ITableForCustomerService table)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _tableForCustomerService = tableForCustomerService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _table = table;
        }

        public async Task SendStatistic()
        {
            var value = _categoryService.TGetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);

            var value2 = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);

            var value3 = _categoryService.TCountOfActiveCategory();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

            var value4 = _categoryService.TCountOfPassiveCategory();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

            var value5 = _productService.TProductNumberByCategoryMain();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryMain", value5);

            var value6 = _productService.TProductNumberByCategoryDessert();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryDessert", value6);

            var value7 = _productService.TAvarageProductPrice();
            await Clients.All.SendAsync("ReceiveAvarageProductPrice", value7.ToString("0.00") + "  ₺");

            var value8 = _productService.THighestPriceProduct().Name;
            await Clients.All.SendAsync("ReceiveHighestProductPrice", value8);

            var value9 = _productService.TLowestPriceProduct().Name;
            await Clients.All.SendAsync("ReceiveLowestProductPrice", value9);

            var value10 = _productService.TAvarageMainMealPrice();
            await Clients.All.SendAsync("ReceiveAvarageMainMealPrice", value10.ToString("0.00") + "  ₺");

            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

            var value13 = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderCount", value13.ToString("0.00") + "  ₺");

            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "  ₺");

            var value15 = _orderService.TTodaysEarningsAmount();
            await Clients.All.SendAsync("ReceiveTodaysEarningsAmount", value15.ToString("0.00") + "  ₺");

            var value16 = _tableForCustomerService.TTableCount();
            await Clients.All.SendAsync("ReceiveTableCount", value16);
        }

        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "  ₺");
        }

        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
        public async Task GetNotificationCount()
        {
            var value = _notificationService.TGetUnreadNotificationCount();
            await Clients.All.SendAsync("NotificationCount", value);

            var list = _notificationService.TGetUnreadNotificationList();
            await Clients.All.SendAsync("NotificationsList", list);
        }
        public async Task GetTableList()
        {
            var value = _table.TGetListAll();
            await Clients.All.SendAsync("TableList", value);
        }
    }
}
