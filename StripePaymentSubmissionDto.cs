
public class StripePaymentSubmissionDto
{
    public string Domain { get; set; } = "";
    public string SuccessRoute { get; set; } = "";
    public string FailRoute { get; set; } = "";
    public string ProductId { get; set; } = "";
    public int Quantity { get; set; } = 0;
}