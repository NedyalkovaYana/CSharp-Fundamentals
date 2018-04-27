using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public  class Engine
{
    public void Run()
    {
        var devices = this.SetTrafficLights();
        var numbersOfLightChanges = int.Parse(Console.ReadLine());
        Console.WriteLine(this.ChangeLights(devices, numbersOfLightChanges));
    }

    private string ChangeLights(Queue<TrafficLight> devices, int numbersOfLightChanges)
    {
        var sb = new StringBuilder();

        while (numbersOfLightChanges > 0)
        {
            foreach (var device in devices)
            {
                device.ChangeLight();
                sb.Append($"{device.Light} ");
            }

            sb.Remove(sb.Length - 1, 1)
                .AppendLine();

            numbersOfLightChanges--;
        }

        return sb.ToString().Trim();
    }

    private Queue<TrafficLight> SetTrafficLights()
    {
        var devicesLightFormatInput = Console.ReadLine().Split();
        var devices = new Queue<TrafficLight>();

        foreach (var lightAsAtring in devicesLightFormatInput)
        {
            LightColor light;

            var isValid = Enum.TryParse(lightAsAtring, out light);

            if (isValid)
            {
                devices.Enqueue(new TrafficLight(light));
            }
        }

        return devices;
    }
}

