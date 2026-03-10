namespace SupplierHub.Constants
{
	public enum RequisitionStatus
	{
		Draft = 1,      // Saved but not sent
		Submitted = 2,  // Sent for approval
		Approved = 3,   // Approval flow completed
		Rejected = 4,   // Denied by an approver
		Converted = 5   // Successfully turned into a Purchase Order
	}
}