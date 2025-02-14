// See https://aka.ms/new-console-template for more information

using TokenGenerator;

var token = JwtTokenGenerator.GenerateToken();
Console.WriteLine("Generated JWT: " + token);