using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables for the person's name and list of jobs
    private string _name;
    private List<Job> _jobs;

    // Constructor to initialize the resume with a name and an empty job list
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();  // Initialize the job list
    }

    // Method to add a job to the resume
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Display method to show the resume details
    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}:");
        foreach (var job in _jobs)
        {
            job.DisplayJobDetails();  // Display each job's details
        }
    }
}
