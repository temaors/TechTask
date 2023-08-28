using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using TechTask.Models.Entities;

namespace TechTask.Validators;

public static class PasswordValidator
{
    private static readonly Regex PasswordRegex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$");

    public static bool IsValid(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            return false;
        }

        return PasswordRegex.IsMatch(password);
    }
}