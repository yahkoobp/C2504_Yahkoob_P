/*
5.Implement a Class Hierarchy with Method Overriding and Interfaces
   - Task: Create an interface `IIdentifiable` with a method `GetId()`. Create an abstract class `Document` that implements `IIdentifiable` and has a method `Print()`. Derive classes `Invoice` and `Receipt` from `Document`.
   - Requirements:
     - `Invoice` should have properties `InvoiceNumber` and `Amount`. Implement the `GetId()` method to return the invoice number and `Print()` to print invoice details.
     - `Receipt` should have properties `ReceiptNumber` and `TotalAmount`. Implement the `GetId()` method to return the receipt number and `Print()` to print receipt details.
   - Example:
     ```csharp
     Document invoice = new Invoice("INV001", 1000);
Console.WriteLine(invoice.GetId()); // Output: INV001
invoice.Print(); // Output: Invoice details

Document receipt = new Receipt("REC001", 200);
Console.WriteLine(receipt.GetId()); // Output: REC001
receipt.Print(); // Output: Receipt details
*/

using System;

interface IIdentifiable
{
    string GetId();
}

abstract class Document : IIdentifiable
{
    public abstract string GetId();
    public abstract void Print();
}

class Invoice : Document
{
    public string InvoiceNumber { get; set; }
    public decimal Amount { get; set; }

    public Invoice(string invoiceNumber, decimal amount)
    {
        InvoiceNumber = invoiceNumber;
        Amount = amount;
    }

    public override string GetId()
    {
        return InvoiceNumber;
    }

    public override void Print()
    {
        Console.WriteLine($"Invoice Number: {InvoiceNumber}, Amount: {Amount}");
    }
}

class Receipt : Document
{
    public string ReceiptNumber { get; set; }
    public decimal TotalAmount { get; set; }

    public Receipt(string receiptNumber, decimal totalAmount)
    {
        ReceiptNumber = receiptNumber;
        TotalAmount = totalAmount;
    }

    public override string GetId()
    {
        return ReceiptNumber;
    }

    public override void Print()
    {
        Console.WriteLine($"Receipt Number: {ReceiptNumber}, Total Amount: {TotalAmount}");
    }
}

class Program
{
    static void Main()
    {
        Document invoice = new Invoice("INV001", 1000);
        Console.WriteLine(invoice.GetId()); // Output: INV001
        invoice.Print(); // Output: Invoice Number: INV001, Amount: 1000

        Document receipt = new Receipt("REC001", 200);
        Console.WriteLine(receipt.GetId()); // Output: REC001
        receipt.Print(); // Output: Receipt Number: REC001, Total Amount: 200
    }
}
