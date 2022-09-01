# API iot exercise1 from Hans

## In this task do the following:
In this practice task, which is not grade-based or exam-based, you must go through what we did in the last lesson and practice this. You must do this in three different parts.

### ASP.NET Core Web API
In this part, you must create two routes in an api that handles the creation of an IoT device. You should start from what we did in the lesson when it comes to creating a web api that can handle the creation of an IoT device. Keep in mind that the web api itself will be a Service, which means that you will have to use the Service SDK called Microsoft.Azure.Devices. The actual creation of an IoT device requires that you have sent a deviceId. So this is something that needs to be done.

You should then make a route with functionality where you can retrieve a specific IoT device based on its deviceId. If no IoT device is found with the deviceId you specified, it will create a device.

### Azure Functions
In this part, you will create an Azure Function in Azure and create two different functions. One called GetDevice and one called CreateDevice. Both of these should do the same thing as mentioned in the above part.

### Console App

You will create an IoT device that is built as a console application. This should then be able to connect to one of the WebApi, feel free to test both. What should happen is that first the device should test and see if it finds a registered device in an Azure Iot Hub. If it does this, the device should get back a connection string that it can use to activate the device and start sending data. If it is the case that there is no device, then a device should be created with the deviceid that the console application has and then it should get back a connection string that it can use to activate the device and start sending data.

The device must also be able to send data in the form of a loop that must be run every minute. The data to be sent to the Iot Hub must consist of a generated number and a time stamp.
