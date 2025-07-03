using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class CellKnowledgeEntity : KnowledgeEntity
{
    private ValueGetterSetterEntityAttribute<float> _limitAttribute;

    public virtual CellCulturalKnowledge CellKnowledge
    {
        get => Setable as CellCulturalKnowledge;
        private set => Setable = value;
    }

    public CellKnowledgeEntity(
        ValueGetterMethod<CulturalKnowledge> getterMethod, Context c, string id, IEntity parent)
        : base(getterMethod, c, id, parent)
    {
    }

    public CellKnowledgeEntity(Context c, string id, IEntity parent) : base(c, id, parent)
    {
    }

    public override EntityAttribute GetAttribute(string attributeId, IExpression[] arguments = null)
    {
        switch (attributeId)
        {
            case LimitAttributeId:
                _limitAttribute =
                    _limitAttribute ?? new ValueGetterSetterEntityAttribute<float>(
                        LimitAttributeId, this, GetLimit, SetLimit);
                return _limitAttribute;
        }

        return base.GetAttribute(attributeId, arguments);
    }

    private float GetLimit()
    {
        if (CellKnowledge == null)
        {
            return 0;
        }

<<<<<<< HEAD:Assets/Scripts/WorldEngine/Modding/Entities/Cultural Attribute Entities/CellKnowledgeEntity.cs
        return CellKnowledge.Limit.Value;
=======
        return CellKnowledge.ScaledLimit;
>>>>>>> alpha4:C#/WorldEngine/Modding/Entities/Cultural Attribute Entities/CellKnowledgeEntity.cs
    }

    private void SetLimit(float value)
    {
        if (CellKnowledge == null)
        {
            return;
        }

<<<<<<< HEAD:Assets/Scripts/WorldEngine/Modding/Entities/Cultural Attribute Entities/CellKnowledgeEntity.cs
        CellKnowledge.Limit.SetValue(value);
=======
        CellKnowledge.ScaledLimit = value;
>>>>>>> alpha4:C#/WorldEngine/Modding/Entities/Cultural Attribute Entities/CellKnowledgeEntity.cs
        CellKnowledge.Group.SetToUpdate(warnIfUnexpected: false);
    }
}
