using SandysBakery.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandysBakery.DataAccess.Services
{
    public interface IAdministrator
    {
        MessageReturnType AddCategory(ProductCategories productCategories);
        MessageReturnType EditCategory(ProductCategories productCategories);
        DataTable ProductCategoriesList();
        ProductCategories GetProductCategoryById(int Id);
        MessageReturnType AddProduct(ProductItems productItems);
        MessageReturnType EditProduct(ProductItems productItems);
        ProductItems GetProductById(int ProductId);
        DataTable ProductList();
        List<ProductItems> ProductItemsPerCategoryById(int categoryById);
        ProductItems ProductItemById(int ProductItemId);
        MessageReturnType AddItemsToCart(CartItems addToCart);
        MessageReturnType RemoveItemsFromCart(int cartId);
        DataTable DisplayItemsInCart(int userId);
        DataTable CommonStatus(int groupNumber);
        MessageReturnType AddPaymentOptions(PaymentGateway paymentGateway);
        DataTable PaymentDetailsByUserId(int userId);
        PaymentGateway GetPaymentGatewayById(int paymentGatewayId);
        MessageReturnType EditPaymentOptions(PaymentGateway paymentGateway);
        MessageReturnType Order(Order order);
        DataTable DisplayOrderedItems(int userId, string roleName, string requestFrom = "", DateTime? dateTime = null);
        MessageReturnType UpdateOrderStatus(int orderId, int orderStatusId);
        MessageReturnType UpdateOrderStatus(DateTime addedDate, int userId, int orderStatusId);
        MessageReturnType AddFeedback(Feedback feedback);
        DataTable FeedBackList();
    }
}