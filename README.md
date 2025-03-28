# nttdatapay-aspdotnet-csharp

## Introduction

This is an example of integration code for ASP.NET (C#), illustrating the process of incorporating the NTTDATA Payment Gateway into your .NET application.

## Prerequisites

- .NET framwork 4.7.2

## Project Structure

The project contains the following files and folder: -POJO-Contain classes for require entities -Default-sample page for show token and initiate the checkout page. -Default.aspx- includes code for initiating payment requests, generating tokens, and implementing encryption logic.c-Response-sample page for show response -Response.aspx-includes code for capturing payment responses and implementing encryption logic.

## Integration

1. Ensure that the .NET Framework version 4.7.2 is installed . 
2. Add all require namespaces in page. 
3. Copy the code from the page_load or Button_click method in the .cs file to the desired event, such as Page Load or Button click.
4. Modify the request and the keys used for encryption and decryption. 
5. Update the UAT and Production CDN link.