using System ;
using System.Drawing ;
using System.ComponentModel ;
using System.Windows.Forms ;


namespace FilterSimulationWithTablesAndGraphs
{
public class ColorButton : System.Windows.Forms.Button
{
    private System.ComponentModel.Container components = null ;

    private Color buttonColor /*= Color.Transparent*/ ;
    private bool buttonPushed = false ;    

    public event EventHandler Changed ;

    public Color Color
    {
        get { return buttonColor ; }
        set { buttonColor = value ; }
    }     

    protected virtual void OnChanged( EventArgs e )
    {
        if( Changed != null )
            Changed( this, e ) ;
    }

    public ColorButton()
    {
        InitializeComponent() ;
    }

   protected override void Dispose( bool disposing )
    {
        if( disposing )
        {
            if( components != null )
                components.Dispose() ;
        }

        base.Dispose( disposing ) ;
    }

    #region Vom Komponenten-Designer generierter Code
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container() ;
    }
    #endregion

    protected override void OnPaint( PaintEventArgs e )
    {
        base.OnPaint( e ) ;

        int offset = 0 ;

        if( ( buttonPushed &&
            RectangleToScreen( ClientRectangle ).Contains( Cursor.Position ) ) )
        {
            ControlPaint.DrawButton( e.Graphics, e.ClipRectangle, ButtonState.Pushed ) ;
            offset = 1 ;
        }

        Rectangle rc = new Rectangle( e.ClipRectangle.Left + 5 + offset,
                                      e.ClipRectangle.Top + 5 + offset,
                                      e.ClipRectangle.Width - 24,
                                      e.ClipRectangle.Height - 11 ) ;
        Pen darkPen = new Pen( SystemColors.ControlDark ) ;

        if( Enabled )
        {
            e.Graphics.FillRectangle( new SolidBrush( buttonColor ), rc ) ;
            e.Graphics.DrawRectangle( darkPen, rc ) ;
        }

        e.Graphics.DrawLine( darkPen, rc.Right + 4, rc.Top, rc.Right + 4, rc.Bottom ) ;
        e.Graphics.DrawLine( new Pen( SystemColors.ControlLightLight ),
                             rc.Right + 5, rc.Top, rc.Right + 5, rc.Bottom ) ;

        Pen textPen = new Pen( Enabled ? SystemColors.ControlText : SystemColors.GrayText ) ;
        Point pt = new Point( rc.Right, ( e.ClipRectangle.Height + offset ) / 2 ) ;

        e.Graphics.DrawLine( textPen, pt.X +  9, pt.Y - 1, pt.X + 13, pt.Y - 1 ) ;
        e.Graphics.DrawLine( textPen, pt.X + 10, pt.Y,     pt.X + 12, pt.Y     ) ;
        e.Graphics.DrawLine( textPen, pt.X + 11, pt.Y,     pt.X + 11, pt.Y + 1 ) ;
    }

    protected override void OnMouseDown( MouseEventArgs e )
    {
        buttonPushed = true ;
        base.OnMouseDown( e ) ;
    }

    protected override void OnMouseUp( MouseEventArgs e )
    {
        buttonPushed = false ;
        base.OnMouseUp( e ) ;
    }


    colorPaleteForm colorPaleteForm;
    protected override void OnClick( EventArgs e )
    {
        if(colorPaleteForm == null||colorPaleteForm.IsDisposed)
            colorPaleteForm = new colorPaleteForm(this);
        
        colorPaleteForm.Color = Color;
        colorPaleteForm.Show();
        colorPaleteForm.BringToFront();
    }
}
}
