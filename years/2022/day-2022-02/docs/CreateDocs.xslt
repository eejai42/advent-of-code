<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                >
    <xsl:output method="xml" indent="yes"/>
    <xsl:include href="../CommonXsltTemplates.xslt"/>
    <xsl:param name="output-filename" select="'output.txt'" />

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="/*">
        <FileSet>
            <FileSetFiles>
                <FileSetFile>
                    <RelativePath>
                        <xsl:text>RockPaperScissors.md</xsl:text>
                    </RelativePath>
                    <xsl:element name="FileContents" xml:space="preserve">
# Rock Paper Scissors
The Elves begin to set up camp on the beach. To decide whose tent gets to be closest to the snack storage, 
a giant Rock Paper Scissors tournament is already in progress.

Rock Paper Scissors is a game between two players. Each game contains many rounds; in each round, the players 
each simultaneously choose one of Rock, Paper, or Scissors using a hand shape. Then, a winner for that round 
is selected: 

<xsl:for-each select="//Signs/Sign"><xsl:sort select="ValueWhenThrown"/><xsl:value-of select="Name"  /> defeats <xsl:value-of select="WinsAgainstName"  />
&lt;img src="<xsl:value-of select="Image"/>" style="width: 5em;" />
&lt;img src="<xsl:value-of select="WinsAgainstImage"/>" style="width: 5em;" />
</xsl:for-each>

If both players choose the same shape, the round instead ends in a draw.

Appreciative of your help yesterday, one Elf gives you an encrypted strategy guide (your puzzle input) that they say 
will be sure to help you win. "The first column is what your opponent is going to play: 

<xsl:for-each select="//Signs/Sign"><xsl:sort select="ValueWhenThrown"/><xsl:value-of select="OpponentCode"  /> for <xsl:value-of select="Name"  />
</xsl:for-each>

The second column--" Suddenly, the Elf is called away to help with someone's tent.

The second column, you reason, must be what you should play in response: 

<xsl:for-each select="//Signs/Sign"><xsl:sort select="ValueWhenThrown"/><xsl:value-of select="SuggestionCode"  /> for <xsl:value-of select="Name"  />
</xsl:for-each>

Winning every time would be suspicious, so the responses must have been carefully chosen.

The winner of the whole tournament is the player with the highest score. Your total score is the sum of 
your scores for each round. The score for a single round is the score for the shape you selected 

<xsl:for-each select="//Signs/Sign"><xsl:sort select="ValueWhenThrown"/><xsl:value-of select="ValueWhenThrown"  /> for <xsl:value-of select="Name"  />
</xsl:for-each>

plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).

Since you can't be sure if the Elf is trying to help you or trick you, you should calculate the score you 
would get if you were to follow the strategy guide.

For example, suppose you were given the following strategy guide:

<xsl:for-each select="//SampleGame/SampleRound"><xsl:sort select="Name"/>
<xsl:value-of select="Name"/></xsl:for-each>

This strategy guide predicts and recommends the following:

                        
<xsl:for-each select="//SampleGame">
    <xsl:for-each select="SampleRound"><xsl:sort select="Name"/>
**<xsl:value-of select="Name"/>**

 - **Opponent Chooses:** <xsl:value-of select="OpponentPlays" />   (<xsl:value-of select="OppenentCode" />)
 - **You should play:** <xsl:value-of select="SuggestionName" /> (<xsl:value-of select="SuggestionCode" />)
 - **Result:** <xsl:value-of select="RoundStatus" />
 - **Final Score:** <xsl:value-of select="SuggestionThrowValue" /> + <xsl:value-of select="Score -SuggestionThrowValue" /> = <xsl:value-of select="Score" />

 - **"Purple" Notes:** <xsl:value-of select="Notes"/>
</xsl:for-each>

In this example, if you were to follow the strategy guide, you would get a total score of <xsl:value-of select="GameScore" /> (<xsl:for-each select="SampleRound"><xsl:sort select="Name"/><xsl:if test="position() > 1"> + </xsl:if><xsl:value-of select="Score"/> </xsl:for-each>).

</xsl:for-each>

What would your total score be if everything goes exactly according to your strategy guide?

</xsl:element>
                </FileSetFile>
            </FileSetFiles>
        </FileSet>
    </xsl:template>
</xsl:stylesheet>
