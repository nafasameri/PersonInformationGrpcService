using Grpc.Net.Client;
using PersonInformationGrpcService;

var channel = GrpcChannel.ForAddress("https://localhost:7066");
var client = new PersonServices.PersonServicesClient(channel);

try
{
    Console.WriteLine("CREATE");
    var input = new CreatePersonRequest
    {
        DateOfBirth = new DateTime(1997, 11, 13).ToShortDateString(),
        FirstName = "Nafise",
        LastName = "Ameri",
        NationalCode = "0924238011"
    };

    var reply = await client.CreatePersonAsync(input);

    Console.WriteLine($"person id = {reply.Id}");


    Console.WriteLine("GET BY Id");
    var inputGetById = new GetPersonByIdRequest
    {
        Id = 3
    };

    var replyGetById = await client.GetPersonByIdAsync(inputGetById);

    Console.WriteLine(replyGetById);
    Console.WriteLine("Enter a Key ...");
    Console.ReadLine();



    Console.WriteLine("UPDATE");
    var inputUpdate = new UpdatePersonRequest
    {
        Id = 3,
        DateOfBirth = new DateTime(1997, 11, 13).ToShortDateString(),
        FirstName = "Nafas",
        LastName = "Ameri",
        NationalCode = "0924238011"
    };

    var replyUpdate = await client.UpdatePersonAsync(inputUpdate);

    Console.WriteLine($"status update = {replyUpdate}");


    Console.WriteLine("GET BY Id");
    var inputGetById2 = new GetPersonByIdRequest
    {
        Id = 3
    };

    var replyGetById2 = await client.GetPersonByIdAsync(inputGetById2);

    Console.WriteLine(replyGetById2);
    Console.WriteLine("Enter a Key ...");
    Console.ReadLine();


    Console.WriteLine("DELETE");
    var inputDelete = new DeletePersonRequest
    {
        Id = 3
    };

    var replyDelete = await client.DeletePersonAsync(inputDelete);

    Console.WriteLine($"status delete = {replyDelete}");
    Console.WriteLine("Enter a Key ...");
    Console.ReadLine();
}
catch (Exception exp)
{
    Console.WriteLine($"Error is {exp.Message}");
    Console.ReadLine();
}