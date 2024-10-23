namespace UltraGreateDivanShop.Web.Repositories.Extensions;

public static class StringExtensions
{
    private const string controller = "Controller";
    public static string GetNameController(this string val) =>
        val.Split(controller).First();
}