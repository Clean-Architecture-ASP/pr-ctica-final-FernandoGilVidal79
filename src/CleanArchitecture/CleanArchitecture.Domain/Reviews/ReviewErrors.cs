using CleanArchitecture.Domain.Abstractions;
namespace CleanArchitecture.Domain.Reviews;

public static class ReviewErrors 
{
    public static readonly Error NotEligible = new ("Review.NotEligible", "Este review y calificación no se puede elegir, no se ha completado");
    }

