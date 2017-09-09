# IHCExample

This is an example to show how to use the IHCSdkWR library to communicate with the IHC controller.

You can get the library from NuGet under the name **Dingus.IHCSdkWR**
(If it does not download automatically for this example then right click the solution and "Restore NuGet packages")

This example will show you:

* how to create the IHCController object
* Authenticate with the controller
* Get a runtime value from the controller
* Set a runtime value on the controller
* Setup a notification callback to get change to a resource

The example is a simple command line C# program. 
You must specify 4 parameters to the program 
(If you run it directly from visual studio - right click the application click properties, 
select debug and enter the command line parameters)

* ihc url 
* username
* password
* resource id

Like:

IHCExample http://192.168.1.3 admin mysecret 1234

The resource id should be a boolean resource (something on/off)
When the example runs it will change the resource to the opposite and then wait for changes on the same resource until you press a key and the programs will exit.
It you use a resource that controls light, and the light is off before you start the program, the light will turn on. 
After this you can see changes to the light state if you try to turn on/off the light.

## IHC Resources ids

You can find ihc resource ids by looking in the IHC project file - it is a XML file.
An easier way is to use my IHC Alternative Service View application:

http://www.dingus.dk/updated-ihc-alternative-service-view/

You can see a tree view of you your installation, expand and click the resource and get the id. 

## Tell me more

For more information about the IHCSdkWR library look here:

http://www.dingus.dk/ihc-sdk-for-net/

