namespace Oculus.Interaction.Surfaces
{
    public interface ISurfacePatch : ISurface
    {
        /// <summary>
        /// A surface patch is defined as an portion of this
        /// underlying surface.
        /// </summary>
        ISurface BackingSurface { get; }
    }
}
