using System;
using System.Collections.Generic;
using System.Text;

namespace FallenGE.Graphics
{
    /// <summary>
    /// Represents a sprite manager.
    /// </summary>
    public class SpriteManager
    {
        private List<KeyValuePair<string, List<Sprite>>> layer;

        /// <summary>
        /// Create a new sprite manager.
        /// </summary>
        public SpriteManager()
        {
            layer = new List<KeyValuePair<string, List<Sprite>>>();
            layer.Add(new KeyValuePair<string, List<Sprite>>("base", new List<Sprite>()));
        }

        /// <summary>
        /// Add a layer to the manager.
        /// </summary>
        /// <param name="name">Name of the layer.</param>
        public void AddLayer(string name)
        {
            layer.Add(new KeyValuePair<string, List<Sprite>>(name, new List<Sprite>()));
        }

        /// <summary>
        /// Remove a layer from the manager.
        /// </summary>
        /// <param name="name">Name of the layer.</param>
        public void RemoveLayer(string name)
        {
            foreach (KeyValuePair<string, List<Sprite>> pair in layer)
            {
                if (pair.Key == name)
                {
                    layer.Remove(pair);
                    return;
                }
            }
        }

        /// <summary>
        /// Remove a layer by index.
        /// </summary>
        /// <param name="i">Index of the layer.</param>
        public void RemoveLayer(int i)
        {
            layer.RemoveAt(i);
        }

        /// <summary>
        /// Get list of sprites containted in a layer.
        /// </summary>
        /// <param name="name">Layer name.</param>
        /// <returns>The list of sprites.</returns>
        public List<Sprite> GetLayer(string name)
        {
            foreach (KeyValuePair<string, List<Sprite>> pair in layer)
            {
                if (pair.Key == name)
                    return pair.Value;
            }
            return null;
        }

        /// <summary>
        /// Get list of sprites containted in layer by index.
        /// </summary>
        /// <param name="i">Index of the layer.</param>
        /// <returns>List of sprites.</returns>
        public List<Sprite> GetLayer(int i)
        {
            return layer[i].Value;
        }

        /// <summary>
        /// Sort a layer of sprites by the sprite z value.
        /// </summary>
        /// <param name="name">Name of the layer to sort.</param>
        public void SortLayer(string name)
        {
            List<Sprite> layer = GetLayer(name);
            layer.Sort(Sprite.Compare);
        }

        /// <summary>
        /// Add a sprite to a layer.
        /// </summary>
        /// <param name="layerName">Name of layer to add sprite to.</param>
        /// <param name="sprite">The sprite to be added.</param>
        public void AddSprite(string layerName, Sprite sprite)
        {
            List<Sprite> layer = GetLayer(layerName);
            layer.Add(sprite);
        }

        /// <summary>
        /// Render a layer of sprites.
        /// </summary>
        /// <param name="renderer">Renderer to use.</param>
        /// <param name="name">Name of the layer to render.</param>
        public void RenderLayer(Renderer renderer, string name)
        {
            foreach (Sprite sprite in GetLayer(name))
                sprite.Render(renderer);
        }

        /// <summary>
        /// Update a layer of sprites.
        /// </summary>
        /// <param name="name">Name of the layer to update.</param>
        /// <param name="delta">Current delta time.</param>
        public void RenderLayer(string name, float delta)
        {
            foreach (Sprite sprite in GetLayer(name))
                sprite.Update(delta);
        }
    }
}
