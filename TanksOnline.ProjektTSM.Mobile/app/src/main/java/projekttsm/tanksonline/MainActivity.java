package projekttsm.tanksonline;

import android.content.Intent;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;

import com.google.android.gms.ads.AdListener;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;
import com.google.android.gms.ads.InterstitialAd;
import com.google.android.gms.ads.MobileAds;
import com.google.gson.JsonObject.*;

import java.util.GregorianCalendar;

public class MainActivity extends AppCompatActivity {

    /*
     * ca-app-pub-4470162864889559~3897919821
     * to wygenerowany klucz aplikacji do AdMoba
     *
     *
     * ca-app-pub-4470162864889559/8328119424
     * a to wygenerowany klucz aplikacji dla baneru
     *
     *
     * ca-app-pub-4470162864889559/3758319020
     * to duży baner ze wszystkim
     *
     *
     * ca-app-pub-4470162864889559/5006002220
     * duży baner tylko z reklamą video
     *
     *
     * ca-app-pub-4470162864889559/5865346227
     * reklama video z nagrodą
     */

    InterstitialAd mInterstitialAd;
    FloatingActionButton btnFabulous;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mInterstitialAd = new InterstitialAd(this);
        mInterstitialAd.setAdUnitId("ca-app-pub-4470162864889559/5006002220");

        mInterstitialAd.setAdListener(new AdListener() {
            @Override
            public void onAdClosed() {
                requestNewInterstitial();
            }
        });
        requestNewInterstitial();

        btnFabulous = (FloatingActionButton)findViewById(R.id.fabulous);
        btnFabulous.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mInterstitialAd.isLoaded()) {
                    mInterstitialAd.show();
                } else {
                    Log.d("TAG", "The interstitial wasn't loaded yet.");
                }
            }
        });

        Button btn = (Button) findViewById(R.id.buttonBzdura) ;
        btn.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                Intent myIntent = new Intent(MainActivity.this, Ranking.class);
                MainActivity.this.startActivity(myIntent);
            }
        });

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i = new Intent(MainActivity.this, ActivityBigVideoAd.class);
                i.putExtra("key", 1234);
                MainActivity.this.startActivity(i);
            }
        });

        MobileAds.initialize(getApplicationContext(), getString(R.string.banner_ad_unit_id));

        AdView mAdView = (AdView) findViewById(R.id.adView);

        if (!BuildConfig.DEBUG) {
            AdRequest adRequest = new AdRequest.Builder()
                    .addTestDevice(AdRequest.DEVICE_ID_EMULATOR)
                    .addTestDevice("27453100DC6F89D12B1DB51D2627E555")
                    .build();
            mAdView.loadAd(adRequest);
        } else {
            AdRequest adRequest = new AdRequest.Builder()
                    .setGender(AdRequest.GENDER_MALE)
                    .setBirthday(new GregorianCalendar(1985, 1, 1).getTime())
                    .addKeyword("game").addKeyword("tanks").addKeyword("arcade").addKeyword("multiplayer")
                    .build();
            mAdView.loadAd(adRequest);
        }
    }

    private void requestNewInterstitial() {
        AdRequest adRequest = new AdRequest.Builder()
                .setGender(AdRequest.GENDER_MALE)
                .setBirthday(new GregorianCalendar(1985, 1, 1).getTime())
                .addKeyword("game").addKeyword("tanks").addKeyword("arcade").addKeyword("multiplayer")
                .build();

        mInterstitialAd.loadAd(adRequest);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
