namespace Pineu.Domain.Entities.MainDomain;
public class FormItem : Entity<Guid> {
    public string Name { get; private set; }
    public string Label { get; private set; }
    public FormName Form { get; private set; }
    public FormItemTemplate Template { get; private set; }
    public int Order { get; private set; }
    public int? Min { get; private set; }
    public int? Max { get; private set; }
    public Guid? IconId { get; private set; }
    public string? Hint { get; private set; }
    public int? Step { get; private set; }
    public Guid? DependOn { get; private set; }

    public IList<FormOption>? FormOptions { get; private set; }

    private FormItem(Guid id) : base(id) { }

    private FormItem(Guid id, string name, string label, FormName form, FormItemTemplate template, int order,
        int? min, int? max, Guid? iconId, string? hint, int? step, Guid? dependOn) : this(id) {
        Name = name;
        Label = label;
        Form = form;
        Template = template;
        Order = order;
        Min = min;
        Max = max;
        IconId = iconId;
        Hint = hint;
        Step = step;
        DependOn = dependOn;
    }

    public static FormItem Create(Guid id, string name, string label, FormName form, FormItemTemplate template, int order,
        int? min, int? max, Guid? iconId, string? hint, int? step, Guid? dependOn) =>
        new(id, name, label, form, template, order, min, max, iconId, hint, step, dependOn);
}
