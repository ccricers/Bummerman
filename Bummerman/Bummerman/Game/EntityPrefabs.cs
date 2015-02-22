﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Bummerman
{
    static class EntityPrefabs
    {
        /// <summary>
        /// Solid block prefab
        /// </summary>
        public static EntityTemplate CreateSolidBlock(int entityID = -1)
        {
            EntityTemplate template = new EntityTemplate(
                "Template",
                new Components.ScreenPosition(),
                new Components.TilePosition(),
                new Components.Sprite()
                {
                    spriteTexture = "blocks",
                    textureArea = new Rectangle(0, 0, 16, 16)
                },
                new Components.Collision()
                {
                    collisionType = CollisionType.SolidBlock,
                    bounds = new Rectangle(0, 0, 16, 16)
                }
            );

            return SetComponentEntityIDs(template, entityID);
        }

        /// <summary>
        /// Soft block prefab
        /// </summary>
        public static EntityTemplate CreateSoftBlock(int entityID = -1)
        {
            EntityTemplate template = new EntityTemplate(
                "Template",
                new Components.ScreenPosition(),
                new Components.TilePosition(),
                new Components.Sprite()
                {
                    spriteTexture = "blocks",
                    textureArea = new Rectangle(16, 0, 16, 16)
                },
                new Components.Collision()
                {
                    collisionType = CollisionType.SolidBlock,
                    bounds = new Rectangle(0, 0, 16, 16)
                }
            );

            return SetComponentEntityIDs(template, entityID);
        }

        /// <summary>
        /// Player prefab
        /// </summary>
        public static EntityTemplate CreatePlayer(int entityID = -1)
        {
            EntityTemplate template = new EntityTemplate(
                "Template",
                new Components.PlayerInfo()
                {
                    playerNumber = 0
                },
                new Components.InputContext(
                    new KeyValuePair<Keys, InputActions>[]
                    {
                        new KeyValuePair<Keys, InputActions>(Keys.Space, InputActions.setBomb),
                        new KeyValuePair<Keys, InputActions>(Keys.Enter, InputActions.remoteTrigger),
                    },
                    new KeyValuePair<Keys, InputStates>[]
                    {
                        new KeyValuePair<Keys, InputStates>(Keys.Down, InputStates.MoveDown),
                        new KeyValuePair<Keys, InputStates>(Keys.Up, InputStates.MoveUp),
                        new KeyValuePair<Keys, InputStates>(Keys.Right, InputStates.MoveRight),
                        new KeyValuePair<Keys, InputStates>(Keys.Left, InputStates.MoveLeft),
                    }
                ),
                new Components.ScreenPosition(),
                new Components.TilePosition(),
                new Components.Sprite()
                {
                    spriteTexture = "player",
                    textureArea = new Rectangle(0, 0, 16, 16)
                },
                new Components.Collision()
                {
                    collisionType = CollisionType.Player,
                    bounds = new Rectangle(0, 0, 16, 16)
                }
            );

            return SetComponentEntityIDs(template, entityID);
        }

        /// <summary>
        /// Set the entity ID for each component here
        /// </summary>
        private static EntityTemplate SetComponentEntityIDs(EntityTemplate template, int ID)
        {
            foreach (Component component in template.componentList)
                component.SetOwnerEntity(ID);

            return template;
        }
    }
}
