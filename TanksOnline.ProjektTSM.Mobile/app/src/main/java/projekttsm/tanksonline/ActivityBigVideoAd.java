package projekttsm.tanksonline;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.Button;

import com.google.android.gms.ads.AdListener;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.AdView;
import com.google.android.gms.ads.InterstitialAd;
import com.google.android.gms.ads.MobileAds;

import java.util.GregorianCalendar;

public class ActivityBigVideoAd extends AppCompatActivity {

    InterstitialAd mInterstitialAd;
    Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_big_video_ad);

        mInterstitialAd = new InterstitialAd(this);
        mInterstitialAd.setAdUnitId("ca-app-pub-4470162864889559/5006002220");

        mInterstitialAd.setAdListener(new AdListener() {
            @Override
            public void onAdClosed() {
                requestNewInterstitial();
            }
        });
    }

    private void requestNewInterstitial() {
        AdRequest adRequest = new AdRequest.Builder()
                .setGender(AdRequest.GENDER_MALE)
                .setBirthday(new GregorianCalendar(1985, 1, 1).getTime())
                .addKeyword("game").addKeyword("tanks").addKeyword("arcade").addKeyword("multiplayer")
                .build();

        mInterstitialAd.loadAd(adRequest);
    }
}
