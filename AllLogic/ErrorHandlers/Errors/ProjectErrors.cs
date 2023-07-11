namespace AllLogic.ErrorHandlers.Errors;

public static class ProjectErrors
{
    public static readonly Func<string, Error> SameNameFound = (name) => new Error("Project.SameNameFound",
        $"There is an existing project with the name {name}");

    public static readonly Func<int, Error> WrongId = (id) => new Error("Project.WrongId",
        $"There is no project with id {id}");

    public static readonly Error NotMatchedId = new("Protect.NotMatchedId",
        "The id from url and from body did not match!");
}