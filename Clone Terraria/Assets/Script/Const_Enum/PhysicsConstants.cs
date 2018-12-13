using UnityEngine;


class PhysicsConstants
{
    public const float MAXSPEED    = 8;
    public const int   MAXHEIGHT   = 6;
    public const float HEIGHT      = 4;  //4格高
    public const float FALLINGTIME = 0.5f; //跳起+落下的時間

    private float heightOffset;
    private float velocityInit;
    private float gravityModifier;

    public float HeightOffset
    {
        get { return heightOffset; }
    }
    public float VelocityInit
    {
        get { return velocityInit; }
    }
    public float GravityModifier
    {
        get { return gravityModifier; }
    }

    public PhysicsConstants( GameObject character )
    {
        heightOffset = character.GetComponent<BoxCollider2D>().size.y / 2f + 0.1f;
        setAllPhyscisNumber();
    }

    private void setAllPhyscisNumber()
    {
        setGravityModifier();
        setVelocityInit();
    }
    private void setVelocityInit()
    {
        float g = Mathf.Abs(Physics2D.gravity.y) * gravityModifier;
        float h = MAXHEIGHT + HeightOffset;
        velocityInit = Mathf.Sqrt(h * 2 * g);
    }
    private void setGravityModifier()
    {
        float g = Mathf.Abs(Physics2D.gravity.y);

        gravityModifier = ( ( HEIGHT * 2 ) / Mathf.Pow(FALLINGTIME / 2 ,2) ) / g;
        gravityModifier = ( gravityModifier <= 1 ) ? 1f : gravityModifier;
    }
}