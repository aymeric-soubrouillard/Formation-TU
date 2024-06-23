using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class Checkout2
{
    private readonly HttpClient httpClient = new HttpClient();

    public async Task<decimal> ProcessCheckout(ShoppingCart cart)
    {
        double totalWeight = 0;
        foreach (var product in cart.GetProducts())
        {
            totalWeight += product.Weight;
        }

        var response = await httpClient.PostAsync("https://api.laposte.fr/shipping/calculate", new StringContent($"{{\"weight\":{totalWeight}}}", System.Text.Encoding.UTF8, "application/json"));
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var jsonObject = JObject.Parse(jsonResponse);

        decimal shippingCost = jsonObject["price"].Value<decimal>();
        
        return cart.TotalAmount + shippingCost;
    }
}
