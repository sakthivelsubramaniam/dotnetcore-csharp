namespace ResultMonad
{
    public class ErrorItem
    {

       public string Message { get; set; }

       public ErrorItem(string message)
       {
         this.Message = message;
       } 
    }
}