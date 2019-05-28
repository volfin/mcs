using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MCS.CONSTANTS;
using MCS.FOUNDATIONS;

namespace MCS.COSTUMING
{
	/// <summary>
	/// The CIbody class contains information on an idividual body item.
	/// Inheriting from CostumeItem, which in turn is a MonoBehaviour; making this class a Component class.
	/// </summary>
	public class CIbody : CostumeItem
	{
		/// <summary>
		/// The backup texture.
		/// </summary>
		public Texture2D backupTexture;

        public Material bodyMat;

        public Material headMat;

        public Material eyeMat;

		/// <summary>
		/// Adds a given CoreMesh reference to the interal LOD list.
		/// </summary>
		/// <param name="cm">The CoreMesh reference to add.</param>
		override public void AddCoreMeshToLODlist (CoreMesh cm)
		{
			if (backupTexture == null)
				backupTexture = cm.skinnedMeshRenderer.sharedMaterial.mainTexture as Texture2D;
			base.AddCoreMeshToLODlist (cm);
		}

        /// <summary>
        /// Returns the Material in the specified MATERIAL_SLOT
        /// </summary>
        public Material GetActiveMaterialInSlot(MATERIAL_SLOT querySlot)
        {
            Material[] sharedMaterials = base.GetSkinnedMeshRenderer().sharedMaterials;

            for (int i = 0; i < sharedMaterials.Length; i++)
            {
                if (sharedMaterials[i] != null)
                {
                    string name = sharedMaterials[i].name.ToLower();

                    MATERIAL_SLOT slot = MATERIAL_SLOT.UNKNOWN;

                    if (name.Contains("head"))
                    {
                        slot = MATERIAL_SLOT.HEAD;
                    }
                    else if (name.Contains("body"))
                    {
                        slot = MATERIAL_SLOT.BODY;
                    }
                    else if (name.Contains("genesis2"))
                    {
                        slot = MATERIAL_SLOT.BODY;
                    }
                    else if (name.Contains("eyeandlash"))
                    {
                        slot = MATERIAL_SLOT.EYEANDLASH;
                    }

                    if (querySlot.Equals(slot))
                    {
                        return sharedMaterials[i];
                    }
                }
            }

            return null;
        }
	}
}
