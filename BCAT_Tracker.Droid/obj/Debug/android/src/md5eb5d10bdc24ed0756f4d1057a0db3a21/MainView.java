package md5eb5d10bdc24ed0756f4d1057a0db3a21;


public class MainView
	extends mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("BCAT_Tracker.Droid.Views.MainView, BCAT_Tracker.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainView.class, __md_methods);
	}


	public MainView ()
	{
		super ();
		if (getClass () == MainView.class)
			mono.android.TypeManager.Activate ("BCAT_Tracker.Droid.Views.MainView, BCAT_Tracker.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
